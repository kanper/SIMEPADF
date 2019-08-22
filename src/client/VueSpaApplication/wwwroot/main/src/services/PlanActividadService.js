import AbstractService from './AbstractService'

export default class PlanActividadService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}plan-trabajo/actividad`);
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl.replace('actividad','')}${params.idPlan}/actividad`)
    }

    add(model, params) {
        return this.axios.post(`${this.baseUrl.replace('actividad','')}${params.idPlan}/actividad`, model)
    }
}