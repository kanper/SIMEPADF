import AbstractService from './AbstractService'

export default class ProyectoOnProcessService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto`);
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl}/estado/${params.status}/pais/${params.country}`);
    }

    executeAction(id, action, params) {
        switch (action) {
            case 'mark':
                return this.axios.get(`${this.baseUrl}/${id}/estado/${params.status}/pais/${params.country}/check`);
            case 'active':
                this.addNotification(params, 'En Proceso', '4');
                return this.changeProjectStatus(id,'EN_PROCESO');
            case 'cancel':
                this.addNotification(params, 'Cancelado', '2$3');
                return this.changeProjectStatus(id,'CANCELADO');
            case 'finalize':
                this.addNotification(params, 'Finalizado', '2$3');
                return this.changeProjectStatus(id,'FINALIZADO');
            case '1review':
                this.addNotification(params, 'Primera Revisión', '5');
                return this.changeProjectStatus(id,'1REVISION');
            case '2review':
                this.addNotification(params, 'Segunda Revisión', '3');
                return this.changeProjectStatus(id,'2REVISION');
            case '3review':
                this.addNotification(params, 'Tercera Revisión', '2');
                return this.changeProjectStatus(id,'3REVISION');
            default:
                return null;
        }
    }

    changeProjectStatus(id,status){
        return this.axios.get(`${this.baseUrl}/${id}/estado/${status}`);
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

    reject(id, observation, rejectBy){
        return this.axios.get(`${this.baseUrl}/${id}/retornar/${observation}/usuario/${rejectBy}`)
    }

}