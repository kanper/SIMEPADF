import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import OrganizacionIndex from './components/organizaciones/Index'
import PaisIndex from './components/paises/Index'
import SocioIndex from './components/socios/Index'
import ObjetivoIndex from './components/objetivo/Index'
import ObjetivoResultadoIndex from './components/resultado/IndexOR'
import ResultadoIndex from './components/resultado/Index'
import ResultadoActividadIndex from './components/actividad/IndexRA'
import ActividadIndex from './components/actividad/Index'
import IndicadorIndex from './components/indicador/Index'
import ProyectoIndex from './components/proyecto/Index'
import ProyectoGestionIndex from './components/proyecto/gestion/Index'
import ProyectoProcesoIndex from './components/proyecto/proceso/Index'
import ProyectoTerminadoIndex from './components/proyecto/terminado/Index'
import FuenteDatoIndex from './components/fuenteDato/Index'
import DesagreacionIndex from './components/desagregacion/Index'
import NivelImpactoIndex from './components/nivelImpacto/Index'
import PlanIndex from './components/plan/Index'
import PlanTrabajoIndex from './components/planTrabajo/Index'
import ActividadPTIndex from './components/actividadPT/Index'
import PlanActividadIndex from './components/actividadPT/IndexPt'
import ProductoIndex from './components/producto/Index'
import ActividadProductoIndex from './components/producto/IndexAP'
import EvidenciaActividadIndex from './components/evidencia/IndexAE'
import EvidenciaProductoIndex from './components/evidencia/IndexPE'
import ProyectoSeguimientoIndicadorIndex from './components/seguimientoDesagregados/IndexPI'
import ProyectoSeguimientoRegistroIndex from './components/seguimientoDesagregados/IndexPS'
import SeguimientoIndicadorDesagregadoIndex from './components/seguimientoIndicadores/IndexSID'
import SeguimientoIndicadorPaisIndex from './components/seguimientoIndicadores/IndexSIP'
import SeguimientoIndicadorRegionIndex from './components/seguimientoIndicadores/IndexSIR'
import AuditoriaIndex from './components/auditoria/Index'
import ProyectoReporteIndex from './components/proyectoReporte/Index'
import UsuarioIndex from './components/usuarios/Index'
import usuarioEditar from './components/usuarios/Editar'
import usuarioChange from './components/usuarios/Change'

Vue.use(Router);

const routes = [
    {path: '/', name: 'home', component: Home},
    {path: '/organizaciones/', name: 'OrganizacionIndex', component: OrganizacionIndex},
    {path: '/paises/', name: 'PaisIndex', component: PaisIndex},
    {path: '/socios/', name: 'SocioIndex', component: SocioIndex},
    {path: '/objetivos/', name: 'objetivo-index', component: ObjetivoIndex},
    {path: '/objetivo/:id/resultados', name: 'objetivo-resultado-index', component: ObjetivoResultadoIndex},
    {path: '/resultados/', name: 'resultado-index', component: ResultadoIndex},
    {path: '/resultado/:id/actividades', name: 'resultado-actividad-index', component: ResultadoActividadIndex},
    {path: '/actividades/', name: 'actividad-index', component: ActividadIndex},
    {path: '/indicadores/', name: 'indicador-index', component: IndicadorIndex},
    {path: '/proyectos/', name: 'proyecto-index', component: ProyectoIndex},
    {path: '/proyectos/gestion', name: 'proyecto-gestion-index', component: ProyectoGestionIndex},
    {path: '/proyectos/proceso', name: 'proyecto-proceso-index', component: ProyectoProcesoIndex},
    {path: '/proyectos/finalizado', name: 'proyecto-finalizado-index', component: ProyectoTerminadoIndex},
    {path: '/usuarios/', name: 'usuario-index', component: UsuarioIndex},
    {path: '/fuente-datos/', name: 'fuente-dato-index', component: FuenteDatoIndex},
    {path: '/desagregaciones/', name: 'desagregacion-index', component: DesagreacionIndex},
    {path: '/niveles-impacto/', name: 'nivel-impacto-index', component: NivelImpactoIndex},
    {path: '/proyecto/:id/plan-monitoreo-evaluacion/', name: 'plan-index', component: PlanIndex},
    {path: '/planes-trabajo/', name: 'plan-trabajo-index', component: PlanTrabajoIndex},
    {path: '/planes-trabajo/actividades', name: 'actividad-pt-index', component: ActividadPTIndex},
    {path: '/planes-trabajo/:id/actividades', name: 'plan-trabajo-actividad-index', component: PlanActividadIndex},
    {path: '/productos', name: 'producto-index', component: ProductoIndex},
    {path: '/actividad/:id/productos', name: 'actividad-producto-index', component: ActividadProductoIndex},
    {
        path: '/plan-trabajo/:id/actividades/evidencia',
        name: 'plan-trabajo-evidencias',
        component: EvidenciaActividadIndex
    },
    {
        path: '/actividad-plan-trabajo/:id/productos/evidencias',
        name: 'producto-evidencias',
        component: EvidenciaProductoIndex
    },
    {path: '/proyecto/:id/seguimiento/seleccion-indicador', name: 'proyecto-seguimiento-seleccion', component: ProyectoSeguimientoIndicadorIndex},
    {path: '/proyecto/:idProyecto/seguimiento/:idIndicador/registro', name: 'proyecto-seguimiento-registro', component: ProyectoSeguimientoRegistroIndex},
    {path: '/seguimiento-indicadores/desagregados', name: 'proyecto-seguimiento-indicador-desagregado', component: SeguimientoIndicadorDesagregadoIndex},
    {path: '/seguimiento-indicadores/pais', name: 'proyecto-seguimiento-indicador-pais', component: SeguimientoIndicadorPaisIndex},
    {path: '/seguimiento-indicadores/region', name: 'proyecto-seguimiento-indicador-region', component: SeguimientoIndicadorRegionIndex},
    {path: '/auditoria/', name: 'AuditoriaIndex', component: AuditoriaIndex},
    {path: '/proyecto/reporte/', name: 'ProyectoReporteIndex', component: ProyectoReporteIndex},
    {path: '/usuarios/', name: 'UsuarioIndex', component: UsuarioIndex},
    {path: '/usuarios/:id/editar', name: 'usuario-editar', component: usuarioEditar},
    {path: '/usuarios/:id/change', name: 'usuario-change', component: usuarioChange},

];

const router = new Router({
    mode: 'history', //removes # from url
    base: '/',
    fallback: true, //router should fallback to hash (#) mode when the browser dos not support history.pushState
    routes //short for `routes: routes`
});

export default new Router({
    routes
})
