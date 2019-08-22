import AbstractService from './AbstractService'

export default class ObjetivoResultadoService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}resultado`)
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl.replace('resultado','')}objetivo/${params.id}/resultados`);
    }


    add(model, params) {
        return this.axios.post(`${this.baseUrl.replace('resultado','')}objetivo/${params.id}/resultados`, model)
    }
}