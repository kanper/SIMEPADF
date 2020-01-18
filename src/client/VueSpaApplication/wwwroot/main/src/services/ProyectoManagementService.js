import AbstractService from './AbstractService'

export default class ProyectoManagementService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto`);
    }

    getAll(params) {
        if(params.all){
            return this.axios.get(`${this.baseUrl}/estado/${params.status}`);
        } else {
            return this.axios.get(`${this.baseUrl}/estado/${params.status}/pais/${params.country}`);
        }
    }

    add(model, params) {
        return this.axios.post(`${this.baseUrl}/estado/${params.defaultStatus}`, model)
    }

    executeAction(id, action, params) {
        switch (action) {
            case 'create':
                return this.create(id);
            case 'active':
                this.addNotification(params, 'En Proceso', '4');
                return this.changeProjectStatus(id,'EN_PROCESO');
            case 'cancel':
                this.addNotification(params, 'Cancelado', '2$3');
                return this.changeProjectStatus(id,'CANCELADO');
            case 'check':
                this.addNotification(params, 'Pendiente Verificación', '2');
                return this.approvalProject(id,params.country);
            case 'finalize':
                this.addNotification(params, 'Finalizado', '2$3');
                return this.changeProjectStatus(id,'FINALIZADO');
            default:
                return null;
        }
    }

    changeProjectStatus(id,status){
        return this.axios.get(`${this.baseUrl}/${id}/estado/${status}`);
    }

    approvalProject(id, country){
        return this.axios.get(`${this.baseUrl}/${id}/aprobar/${country}`);
    }

    create(id) {
        return this.axios.post(`${this.baseUrl}/plan-trabajo/${id}`)
    }

    addNotification(params, status, nextRole){
        let model = {
            titulo: 'Proyecto ' + status,
            mensaje: 'El proyecto "' + params.model.nombreProyecto + '" ha cambiado su estado a ' + status,
            tipo: 'info',
            rol: nextRole,
            nombreUsuario: window.User.Nombre + ' ' + window.User.Apellido,
            codigoUsuario: window.User.UserId,
            pais: params.model.paises.map(function (item) {
                return item.nombre;
            }).join("$")
        };
        this.axios.post(`${this.baseUrl.replace('proyecto','')}alerta`, model);
    }

}