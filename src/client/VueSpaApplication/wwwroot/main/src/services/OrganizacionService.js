import AbstractService from './AbstractService'

export default class OrganizacionService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}organizacion-responsable`);
    }
}
