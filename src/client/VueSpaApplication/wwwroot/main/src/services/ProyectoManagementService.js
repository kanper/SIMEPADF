import AbstractService from './AbstractService'

export default class ProyectoManagementService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto`);
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl}/estado/${params.status}`);
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
                return this.changeProjectStatus(id,'VERIFICAR');
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
            pais: params.model.paises.map(function (item) {
                return item.nombre;
            }).join("$")
        };
        this.axios.post(`${this.baseUrl.replace('proyecto','')}alerta`, model);
    }

}