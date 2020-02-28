import React, {Component} from 'react';
import RowColParams from '../classes/rowColParams';

class RowColumnForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            rowVal:'',
            colVal:''
        };

        this.handleRowChange = this.handleRowChange.bind(this);
        this.handleColChange = this.handleColChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    
    }

    handleRowChange(event) {
        this.setState({rowVal:event.target.value});
    }

    handleColChange(event) {

        this.setState({colVal:event.target.value});
    }

    handleSubmit(event) {
        const parms = new RowColParams(this.state.rowVal, this.state.colVal)   
        console.log(parms);     
        this.props.onSubmitClick(parms);
        event.preventDefault();
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <table><tbody>
                    <tr>
                        <td style={{'textAlign':'right'}}>Row (a-f)</td>
                        <td><input type="text" value={this.state.rowVal} onChange={this.handleRowChange} /></td>
                    </tr>
                    <tr>
                        <td style={{'textAlign':'right'}}>Column (1-12)</td>
                        <td><input type="text" value={this.state.colVal} onChange={this.handleColChange}/></td>
                    </tr>
                    <tr>
                        <td colSpan="2" style={{'textAlign':"center"}}><input type="submit" value="Submit"/></td>
                    </tr>    
                </tbody></table>                
            </form>
        );
    }
}

export default RowColumnForm;