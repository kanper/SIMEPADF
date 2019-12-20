import AbstractService from './AbstractService'

export default class AuditoriaService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}auditoria`);
    }

    getAll(params) {
        switch (params.auditClass) {
            case 'all':
                return this.axios.get(`${this.baseUrl}/all`);
            case 'actividadṔT':
                return this.axios.get(`${this.baseUrl}/actividadṔT`);
            case 'desagregado':
                return this.axios.get(`${this.baseUrl}/desagregado`);
            case 'socio':
                return this.axios.get(`${this.baseUrl}/socio`);
            case 'organizacion':
                return this.axios.get(`${this.baseUrl}/organizacion`);
            case 'pais':
                return this.axios.get(`${this.baseUrl}/pais`);
            case 'nivel':
                return this.axios.get(`${this.baseUrl}/nivel`);
            case 'fuente':
                return this.axios.get(`${this.baseUrl}/fuente`);
            case 'proyecto':
                return this.axios.get(`${this.baseUrl}/proyecto`);
            case 'producto':
                return this.axios.get(`${this.baseUrl}/producto`);
            case 'indicador':
                return this.axios.get(`${this.baseUrl}/indicador`);
            case 'actividad':
                return this.axios.get(`${this.baseUrl}/actividad`);
            case 'resultado':
                return this.axios.get(`${this.baseUrl}/resultado`);
            case 'objetivo':
                return this.axios.get(`${this.baseUrl}/objetivo`);
            default:
                return null;
        }
    }
}