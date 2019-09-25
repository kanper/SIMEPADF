import AbstractService from './AbstractService'

export default class ProyectoManagementService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto`);
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl}/estado/${params.status}`);
    }

    executeAction(id, action, params) {
        switch (action) {
            case 'create':
                return this.create(id);
            case 'active':
                return this.changeProjectStatus(id,'EN_PROCESO');
            case 'cancel':
                return this.changeProjectStatus(id,'CANCELADO');
            case 'check':
                return this.changeProjectStatus(id,'VERIFICAR');
            case 'finalize':
                return this.changeProjectStatus(id,'FINALIZADO');
            default:
                return null;
        }
    }

    changeProjectStatus(id,status){
        return this.axios.get(`${this.baseUrl}/${id}/estado/${status}`);
    }

    create(id) {
        return this.axios.post(`${this.baseUrl}/plan-trabajo/${id}`)
    }

}