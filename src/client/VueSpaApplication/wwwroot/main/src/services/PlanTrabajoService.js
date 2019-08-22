import AbstractService from './AbstractService'

export default class PlanTrabajoService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto/plan-trabajo`);
    }

    executeAction(id, action, params) {
        switch (action) {
            case 'create':
                return this.create(id);
            default:
                console.error("Invalid option action:" + action)
        }
    }

    create(id) {
        return this.axios.post(`${this.baseUrl}/${id}`)
    }

}