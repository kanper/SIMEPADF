import AbstractService from './AbstractService'

export default class PlanTrabajoActividadService extends AbstractService {

    constructor(axios, baseUrl){
        super(axios,`${baseUrl}plan-trabajo`)
    }

    get(id, params) {
        return this.axios.get(`${this.baseUrl}/actividad/${id}/evidencia`)
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl}/${params.id}/actividad/evidencia/${params.pais}`)
    }
}