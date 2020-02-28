import React, {Component} from 'react'
import FormContainer from './formContainer';
import ResultText from './resultText';
import TriangleGrid from './triangleGrid';
import ApiService from '../classes/apiService';

import './layout.css';


class Layout extends Component {
    constructor(props) {
        super(props);
        this.state = {
            apiResult: null
        };
        this.api = new ApiService();
        //this.handleTriangleRequested = this.handleTriangleRequested.bind(this);
    }

    render() {
        return (
            <table className="main"><tbody>
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
                </tbody></table>
        );
    }

    handleTriangleRequested = requestParms => {
        this.api.fetchTriangle(requestParms, this.updateState);
    }

    updateState = data => {
        this.setState({apiResult:data}); 
    }
    
}


export default Layout;