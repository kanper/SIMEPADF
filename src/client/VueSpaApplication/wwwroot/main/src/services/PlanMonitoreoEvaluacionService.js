import AbstractService from './AbstractService'

export default class PlanMonitoreoEvaluacionService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto`);
    }

    get(id, params) {
        return this.axios.get(`${this.baseUrl}/${params.idProyecto}/indicador/${id}`)
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl}/${params.idProyecto}/indicador`)
    }

    add(model, params) {
        return this.axios.post(`${this.baseUrl}/${params.idProyecto}/indicador`, model)
    }

    update(model, id, params) {
        return this.axios.put(`${this.baseUrl}/${params.idProyecto}/indicador/${id}`, model)
    }

    remove(id, params) {
        return this.axios.delete(`${this.baseUrl}/${params.idProyecto}/indicador/${id}`)
    }

    executeAction(id, action, params) {
        return super.executeAction(id, action, params);
    }
}