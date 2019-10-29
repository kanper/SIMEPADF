import AbstractService from './AbstractService'

export default class SimpleIdentificadorService extends AbstractService {

    constructor(axios, baseUrl){
        super(axios, `${baseUrl}identificador`);
    }

    getProyecto(id){
        return this.axios.get(`${this.baseUrl}/proyecto/${id}`)
    }

    getActividadPT(id){
        return this.axios.get(`${this.baseUrl}/actividad-pt/${id}`)
    }
}