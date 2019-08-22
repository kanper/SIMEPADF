import AbstractService from './AbstractService'

export default class ResultadoActividadService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}actividad`);
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl.replace('actividad','')}resultado/${params.id}/actividades`);
    }

    add(model, params) {
        return this.axios.post(`${this.baseUrl.replace('actividad','')}resultado/${params.id}/actividad`, model)
    }
}