import React, {Component} from 'react';
import RowColumnForm from './rowColumnForm'
import PointsForm from './pointsForm';
import FormSelector from './formSelector';
import './formContainer.css';

class FormContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            "rowColClass": "visible",
            "pointsClass": "hidden"
        };
        this.switchForms = this.switchForms.bind(this);
    }

    switchForms(which) {
        let rc = "visible";
        let p = "hidden";
        if (which === "points") {
            rc = "hidden";
            p = "visible";
        }
        this.setState({
            "rowColClass": rc,
            "pointsClass": p
        });
        console.log(this.state);
    }

    render() {
        return (
            <div className="formContainer">
                <h3>Triangle Parameters</h3>
                <FormSelector onChanged={this.switchForms} />
                <div className={this.state.rowColClass}>
                    <RowColumnForm onSubmitClick={this.props.onSubmitClick} />
                </div>
                <div className={this.state.pointsClass}>
                    <PointsForm onSubmitClick={this.props.onSubmitClick} />
                </div>
            </div>
            );
    }
}

export default FormContainer;