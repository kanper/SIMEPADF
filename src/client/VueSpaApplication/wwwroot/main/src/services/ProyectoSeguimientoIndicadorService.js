import AbstractService from './AbstractService'

export default class ProyectoSeguimientoIndicadorService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto`);
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl}/${params.id}/seguimiento/indicadores`)
    }
}