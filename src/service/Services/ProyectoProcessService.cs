using System;
using System.Linq;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Model.Domain.DbHelper;

namespace Services
{
    public interface IProyectoProcessService
    {
        bool ChangeStatus(string idProject, string projectStatus);
        bool Approval(string idProject, string pais);
        bool Check(string idProject, string projectStatus, string pais);
        bool Reject(string idProject, string observation, string username);
    }

    public class ProyectoProcessService : IProyectoProcessService
    {
        private readonly simepadfContext _context;
        private const string InProcess = "EN_PROCESO";
        private const string LastReview = "3REVISION";

        public ProyectoProcessService(simepadfContext context)
        {
            _context = context;
        }

        public bool ChangeStatus(string idProject, string projectStatus)
        {
            try
            {
                CreateReviewSet(idProject, projectStatus);
                var project = _context.Proyecto
                    .Include(s => s.EstadoProyecto)
                    .Single(p => p.CodigoProyecto == idProject);
                project.EstadoProyecto = _context.EstadoProyecto.Single(s => s.TipoEstado == projectStatus);
                if (projectStatus.Equals(InProcess))
                {
                    MarkCompletedActivities(idProject);
                    LockAllRecordSet(idProject);
                    CreateNewRecordSet(idProject);
                    _context.SaveChanges();
                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Approval(string idProject, string pais)
        {
            try
            {
                var country = _context.Pais.Single(p => p.NombrePais == pais);
                var projectCountry =
                    _context.ProyectoPais.Single(p => p.ProyectoId == idProject && p.PaisId == country.Id);
                projectCountry.Aprobado = true;
                projectCountry.FechaAprobado = DateTime.Now;
                _context.SaveChanges();
                PassIfAllCountriesAreApproval(idProject);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Check(string idProject, string projectStatus, string pais)
        {
            try
            {
                var reviewSet = (from project in _context.Proyecto
                    join pp in _context.ProyectoPais
                        on project equals pp.Proyecto
                    join e in _context.EstadoProyecto
                        on project.EstadoProyecto equals e
                    join p in _context.Pais
                        on pp.Pais equals p
                    join r in _context.RegistroRevision
                        on pp equals r.ProyectoPais
                    where project.CodigoProyecto == idProject &&
                          e.TipoEstado == projectStatus &&
                          (p.NombrePais == pais || pais == "all") &&
                          r.RevisionCompleta == false
                    select r).ToArray();
                if (pais == "all")
                {
                    foreach (var revision in reviewSet)
                    {
                        revision.Revisado = true;
                        revision.FechaRevisado = DateTime.Now;
                    }
                }
                else
                {
                    if (reviewSet.First() != null)
                    {
                        reviewSet.First().Revisado = true;
                        reviewSet.First().FechaRevisado = DateTime.Now;
                    }
                }

                _context.SaveChanges();
                CheckIfAllCountryWasReviewed(idProject, projectStatus);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Reject(string idProject, string observation, string username)
        {
            try
            {
                MoveToPrevious(idProject);
                CreateRejectNotification(idProject, observation, username);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private void MoveToNextStatus(string idProject)
        {
            try
            {
                var project = _context.Proyecto
                    .Include(p => p.EstadoProyecto)
                    .Single(p => p.CodigoProyecto == idProject);
                if (project.EstadoProyecto.TipoEstado.Equals(LastReview)) return;
                project.EstadoProyecto = _context.EstadoProyecto.Single(e => e.Id == (project.EstadoProyecto.Id + 1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void MoveToPrevious(string idProject)
        {
            try
            {
                var project = _context.Proyecto
                    .Include(p => p.EstadoProyecto)
                    .Single(p => p.CodigoProyecto == idProject);
                project.EstadoProyecto = _context.EstadoProyecto.Single(e => e.TipoEstado.Equals(InProcess));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void CreateRejectNotification(string id, string observation, string username)
        {
            try
            {
                var countries = (from p in _context.Pais
                    join pp in _context.ProyectoPais on p equals pp.Pais
                    where pp.ProyectoId == id
                    select p.NombrePais).ToArray();
                foreach (var country in countries)
                {
                    CreateAlert(observation, country, username);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void CreateReviewSet(string id, string status)
        {
            if (!status.Equals(InProcess)) return;
            var currentQuarter = _context.RegistroRevision
                .Include(r => r.ProyectoPais)
                .Where(r => r.ProyectoPais.ProyectoId == id);

            foreach (var projectCountry in _context.ProyectoPais
                .Include(rr => rr.RegistroRevisiones)
                .Where(p => p.ProyectoId == id).ToList())
            {
                projectCountry.AddProcesoRevision(!currentQuarter.Any() ? 0 : currentQuarter.Max(r => r.Trimestre));
            }
        }

        private void LockAllRecordSet(string idProject)
        {
            try
            {
                var unlockedRecords = (from d in _context.PlanDesagregacion
                        join r in _context.PlanSocioDesagregacion on d equals r.PlanDesagregacion
                        where d.PlanMonitoreoEvaluacionProyectoCodigoProyecto == idProject &&
                              !r.Locked
                        select r)
                    .ToArray();
                foreach (var record in unlockedRecords)
                {
                    record.Locked = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void CreateNewRecordSet(string idProject)
        {
            try
            {
                var currentQuarter = (from p in _context.PlanSocioDesagregacion
                    where p.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto == idProject
                    select p.Trimestre).Max();
                var socios = (from ps in _context.ProyectoSocio
                    join s in _context.SocioInternacional on ps.SocioInternacional equals s
                    where ps.ProyectoId == idProject
                    select s).ToArray();
                var plan = _context.PlanDesagregacion
                    .Include(p => p.PlanSocios)
                    .Where(p => p.PlanMonitoreoEvaluacionProyectoCodigoProyecto == idProject);
                foreach (var reg in plan)
                {
                    foreach (var socio in socios)
                    {
                        reg.AddPlanSocio(socio, currentQuarter == 4 ? 1 : currentQuarter + 1);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void MarkCompletedActivities(string idProject)
        {
            try
            {
                var currentQuarter = QuarterCalculator.GetQuarter(DateTime.Now);
                var activities = _context.ActividadPT.Where(a => a.PlanTrabajoCodigoPlanTrabajo == idProject);
                foreach (var a in activities)
                {
                    if (a.FechaLimite.Year >= DateTime.Now.Year &&
                        a.FechaInicio.Year <= DateTime.Now.Year && 
                        QuarterCalculator.GetQuarter(a.FechaLimite) >= currentQuarter && 
                        QuarterCalculator.GetQuarter(a.FechaInicio) <= currentQuarter && 
                        !a.Completa)
                        a.Completa = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void PassIfAllCountriesAreApproval(string idProject)
        {
            if (_context.ProyectoPais.Where(p => p.ProyectoId == idProject).All(pp => pp.Aprobado))
            {
                ChangeStatus(idProject, "VERIFICAR");
            }
        }

        private void CheckIfAllCountryWasReviewed(string idProject, string projectStatus)
        {
            var rev = int.Parse(projectStatus.Remove(1));
            var reviewSet = from r in _context.RegistroRevision
                where r.ProyectoPais.ProyectoId == idProject &&
                      r.NumeroRevision == rev &&
                      r.RevisionCompleta == false
                select r;
            if (!reviewSet.All(r => r.Revisado)) return;
            foreach (var revision in reviewSet)
            {
                revision.RevisionCompleta = true;
            }

            MoveToNextStatus(idProject);
            _context.SaveChanges();
        }

        private void CreateAlert(string observation, string country, string username)
        {
            _context.Alertas.Add(new Alerta("Proyecto Retornado", observation, "warnin", "4", country, username));
            _context.SaveChanges();
        }
    }
}