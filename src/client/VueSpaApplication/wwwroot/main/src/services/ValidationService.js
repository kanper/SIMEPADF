import AbstractService from './AbstractService'

export default class ValidationService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}validacion`);
    }

    validateNew(entityName, identifier) {
        return this.axios.get(`${this.baseUrl}/${entityName}/${identifier}`);
    }

    validateUpdate(entityName, id, identifier) {
        return this.axios.get(`${this.baseUrl}/${entityName}/${id}/identificador/${identifier}`)
    }
}