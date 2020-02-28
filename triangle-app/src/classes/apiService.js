import PointParams from './pointParams';
import RowColParams from './rowColParams';

export default class ApiService {
    fetchTriangle(paramsObj, stateCallback) {
        let query = "";
        let resource = "";
        if (paramsObj instanceof RowColParams) {
            query = `?row=${paramsObj.row}&col=${paramsObj.col}`;
            resource = "byrowcol";
        }
        else if (paramsObj instanceof PointParams) {
            query = `?x1=${paramsObj.left1}&y1=${paramsObj.top1}`
                + `&x2=${paramsObj.left2}&y2=${paramsObj.top2}`
                + `&x3=${paramsObj.left3}&y3=${paramsObj.top3}`;
            resource = "bycoords"
        }
        else {
            throw new Error("Unexpected triangle parameter type!");
        }
        const baseUrl = "http://localhost:5000/triangle/" + resource;
        const url = baseUrl + query;
        fetch(url, {mode: 'cors', method:'GET'})
        .then(resp => resp.json())
        .then(data => stateCallback(data))
        .catch(console.log);
    } 
}