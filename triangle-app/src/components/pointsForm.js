import React, {Component} from 'react';
import PointParams from './pointParams';
import './pointsForm.css';

class PointsForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            top1:null,
            left1:null,
            top2:null,
            left2:null,
            top3:null,
            left3:null
        };
    }

    handleTop1Change = e => {this.setState({top1:e.target.value});}
    handleLeft1Change = e => {this.setState({left1:e.target.value});}
    
    handleTop2Change = e => {this.setState({top2:e.target.value});}
    handleLeft2Change = e => {this.setState({left2:e.target.value});}
    
    handleTop3Change = e => {this.setState({top3:e.target.value});}
    handleLeft3Change = e => {this.setState({left3:e.target.value});}
    
    handleSubmit = e => {
        const parms = new PointParams(this.state.top1,
            this.state.left1,
            this.state.top2,
            this.state.left2,
            this.state.top3,
            this.state.left3);   
        console.log(parms);     
        this.props.onSubmitClick(parms);
        e.preventDefault();
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <table className="fieldTable"><tbody>
                    <tr>
                        <td>
                            <label>
                                X1:
                                <input type="text" value={this.state.left1} onChange={this.handleLeft1Change} />
                            </label>
                        </td>
                        <td>
                        <label>
                                Y1:
                                <input type="text" value={this.state.top1} onChange={this.handleTop1Change} />
                            </label>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                X2:
                                <input type="text" value={this.state.left2} onChange={this.handleLeft2Change} />
                            </label>
                        </td>
                        <td>
                        <label>
                                Y2:
                                <input type="text" value={this.state.top2} onChange={this.handleTop2Change} />
                            </label>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                X3:
                                <input type="text" value={this.state.left3} onChange={this.handleLeft3Change} />
                            </label>
                        </td>
                        <td>
                        <label>
                                Y3:
                                <input type="text" value={this.state.top3} onChange={this.handleTop3Change} />
                            </label>                            
                        </td>
                    </tr>
                         
                </tbody></table>
            <input type="submit" value="Submit"/>
            </form>
        );
    }
}

export default PointsForm;