import AbstractService from './AbstractService'

export default class ProyectoService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto`);
    }

    executeAction(id, action, params) {
        switch (action) {
            case 'active':
                return this.changeProjectStatus(id,'EN_PROCESO');
            case 'cancel':
                return this.changeProjectStatus(id,'CANCELADO');
            case 'check':
                return this.changeProjectStatus(id,'VERIFICAR');
            case 'finalize':
                return this.changeProjectStatus(id,'FINALIZADO');
            case '1Review':
                return this.changeProjectStatus(id,'1REVISION');
            case '2review':
                return this.changeProjectStatus(id,'2REVISION');
            case '3review':
                return this.changeProjectStatus(id,'3REVISION');
            default:
                return null;
        }
    }

    changeProjectStatus(id,status){
        return this.axios.get(`${this.baseUrl}/${id}/estado/${status}`);
    }

}