import AbstractService from './AbstractService'

export default class RegistroRevisionService extends AbstractService {

    constructor(axios, baseUrl){
        super(axios,`${baseUrl}registro-revision`);
    }

    findReview(id, status, country) {
        return this.axios.get(`${this.baseUrl}/${id}/estado/${status}/pais/${country}`)
    }

    findAllReview(id, status) {
        return this.axios.get(`${this.baseUrl}/${id}/estado/${status}`)
    }

}