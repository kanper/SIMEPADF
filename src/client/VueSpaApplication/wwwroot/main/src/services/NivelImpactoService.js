import AbstractService from './AbstractService'

export default class NivelImpactoService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}nivel-impacto`);
    }
}