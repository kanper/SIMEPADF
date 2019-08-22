import AbstractService from './AbstractService'

export default class DesagregacionService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}desagregacion`);
    }
}