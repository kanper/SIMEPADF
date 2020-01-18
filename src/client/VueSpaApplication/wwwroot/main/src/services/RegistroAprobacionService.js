import AbstractService from './AbstractService'

export default class RegistroAprobacionService extends AbstractService {

    constructor(axios, baseUrl){
        super(axios,`${baseUrl}registro-aprobacion`);
    }

    findAll(id) {
        return this.axios.get(`${this.baseUrl}/${id}`)
    }

}