import AbstractService from './AbstractService'

export default class ProductoService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}actividad/producto`);
    }
}