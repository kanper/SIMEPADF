import Axios from 'axios'
import paisService from '../services/PaisService'
import socioService from '../services/SocioService'
import organizacionService from '../services/OrganizacionService'
import objetivoService from '../services/ObjetivoService'
import objetivoResultadoService from '../services/ObjetivoResultadoService'
import resultadoService from '../services/ResultadoService'
import resultadoActividadService from '../services/ResultadoActividadService'
import actividadService from '../services/ActividadService'
import indicadorService from '../services/IndicadorService'
import proyectoService from '../services/ProyectoService'
import proyectoHelperService from '../services/ProyectoHelperService'
import proyectoManagementService from '../services/ProyectoManagementService'
import proyectoOnProcessService from '../services/ProyectoOnProcessService'
import proyectoFinalizedService from '../services/ProyectoFinalizedService'
import fuenteDatoService from '../services/FuenteDatoService'
import desagregacionService from '../services/DesagregacionService'
import nivelImpactoService from '../services/NivelImpactoService'
import planMonitoreoEvaluacionService from '../services/PlanMonitoreoEvaluacionService'
import planTrabajoService from '../services/PlanTrabajoService'
import actividadPtService from '../services/ActividadPtService'
import planActividadService from '../services/PlanActividadService'
import productoService from '../services/ProductoService'
import actividadProductoService from '../services/ActividadProductoService'
import proyectoInfoService from '../services/ProyectoInfoService'
import registroRevisionService from '../services/RegistroRevisionService'
import usuarioService from '../services/UsuarioService'

//let apiUrl = 'https://localhost:44320/';
let apiUrl = 'http://localhost:5000/';
let authUrl = 'http://localhost:53153/';


// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json';

export default {
    paisService: new paisService(Axios, apiUrl),
    socioService: new socioService(Axios, apiUrl),
    organizacionService: new organizacionService(Axios, apiUrl),
    objetivoService: new objetivoService(Axios, apiUrl),
    objetivoResultadoService: new objetivoResultadoService(Axios, apiUrl),
    resultadoService: new resultadoService(Axios, apiUrl),
    resultadoActividadService: new resultadoActividadService(Axios, apiUrl),
    actividadService: new actividadService(Axios, apiUrl),
    indicadorService: new indicadorService(Axios, apiUrl),
    proyectoService: new proyectoService(Axios, apiUrl),
    proyectoHelperService: new proyectoHelperService(Axios, apiUrl),
    fuenteDatoService: new fuenteDatoService(Axios, apiUrl),
    desagregacionService: new desagregacionService(Axios, apiUrl),
    nivelImpactoService: new nivelImpactoService(Axios, apiUrl),
    planMonitoreoEvaluacionService: new planMonitoreoEvaluacionService(Axios, apiUrl),
    planTrabajoService: new planTrabajoService(Axios, apiUrl),
    actividadPtService: new actividadPtService(Axios, apiUrl),
    planActividadService: new planActividadService(Axios, apiUrl),
    productoService: new productoService(Axios, apiUrl),
    proyectoInfoService: new proyectoInfoService(Axios, apiUrl),
    actividadProductoService: new actividadProductoService(Axios, apiUrl),
    proyectoManagementService: new proyectoManagementService(Axios, apiUrl),
    proyectoOnProcessService: new proyectoOnProcessService(Axios, apiUrl),
    proyectoFinalizedService: new proyectoFinalizedService(Axios, apiUrl),
    registroRevisionService: new registroRevisionService(Axios, apiUrl),
    usuarioService: new usuarioService(Axios, apiUrl, authUrl)
}