import AbstractService from './AbstractService'

export default class AlertaService extends AbstractService{

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}alerta`);
    }

    getAlerts(rol, country) {
        return this.axios.get(`${this.baseUrl}/rol/${rol}/pais/${country}`);
    }

    check(id) {
        return this.axios.get(`${this.baseUrl}/${id}`);
    }

}