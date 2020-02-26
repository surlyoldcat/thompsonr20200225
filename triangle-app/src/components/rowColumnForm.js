import React, {Component} from 'react';
import RowColParams from './rowColParams';

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
                <label>
                    Row (a-f):
                    <input type="text" value={this.state.rowVal} onChange={this.handleRowChange} />
                </label>
                <br/>
                <label>
                    Column (1-12):
                    <input type="text" value={this.state.colVal} onChange={this.handleColChange}/>
                </label>
                <br/>
                <input type="submit" value="Submit"/>
            </form>
        );
    }
}

export default RowColumnForm;