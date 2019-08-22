import AbstractService from './AbstractService'

export default class IndicadorService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}indicador`);
    }
}