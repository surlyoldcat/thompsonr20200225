import React, { Component } from 'react';

class FormSelector extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selectedOption:"rowcol"
        };
        this.handleOptionChanged = this.handleOptionChanged.bind(this);
    }

    handleOptionChanged(event) {        
        this.setState({selectedOption:event.target.value});
        this.props.onChanged(event.target.value);
    }

    render() {
        return (
            <div><form>
                <label>
                    <input type="radio" 
                        name="formOption"
                        value="rowcol"
                        checked={this.state.selectedOption==="rowcol"}
                        onChange={this.handleOptionChanged} />                    
                    Row/Col
                </label>
                <label>
                    <input type="radio"
                        name="formOption"
                        value="points"
                        checked={this.state.selectedOption==="points"}
                        onChange={this.handleOptionChanged} />
                    Coords
                </label>
            </form></div>
        );
    }
}

export default FormSelector;