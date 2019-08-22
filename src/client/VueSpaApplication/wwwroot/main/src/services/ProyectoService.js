import AbstractService from './AbstractService'

export default class ProyectoService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto`);
    }

    executeAction(id, action, params) {
        switch (action) {
            case 'active':
                return this.activeProject(id);
            case 'cancel':
                return this.cancelProject(id);
            default:
                return null;
        }
    }

    activeProject(id) {
        return this.axios.get(`${this.baseUrl}/${id}/estado/EN PROCESO`);
    }

    cancelProject(id) {
        return this.axios.get(`${this.baseUrl}/${id}/estado/CANCELADO`);
    }
}