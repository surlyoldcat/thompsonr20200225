import React, {Component} from 'react'
import FormContainer from './formContainer';
import ResultText from './resultText';
import TriangleGrid from './triangleGrid';
import RowColParams from './rowColParams';
import PointParams from './pointParams';

import './layout.css';


class Layout extends Component {
    constructor(props) {
        super(props);
        this.state = {
            apiResult: null
        };

        this.handleTriangleRequested = this.handleTriangleRequested.bind(this);
    }

    render() {
        return (
            <table className="main">
                <tr>
                    <td colSpan="2" className="headerCell">
                        <div className="title">
                            <img className="logo" src="/images/triangle.png" alt=""/>
                            &nbsp;Triangle Man
                            </div>
                        <p className="disclaimer">Disclaimer: Rick doesn't know React. This is just a naive test harness.</p>
                    </td>
                </tr>
                <tr>
                    <td className="leftSide">
                        <FormContainer onSubmitClick={this.handleTriangleRequested} />
                        <ResultText value={this.state.apiResult} />
                    </td>
                    <td className="rightSide">
                        <TriangleGrid value={this.state.apiResult} />
                    </td>
                </tr>
            </table>
        );
    }

    //TODO the API interaction should be refactored into a service
    handleTriangleRequested(paramsObj) {
        let query = "";
        let resource = "";
        if (paramsObj instanceof  RowColParams) {
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
        .then(data => this.setState({apiResult:data}))
        .catch(console.log);
    } 
}


export default Layout;