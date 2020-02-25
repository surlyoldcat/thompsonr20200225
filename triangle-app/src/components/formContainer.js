import React from 'react';
import RowColumnForm from './rowColumnForm'

function FormContainer(props) {
    return (
        <div className="formContainer">
            <h3>Triangle Parameters</h3>
            <RowColumnForm onSubmitClick={props.triangleRequested}/>
        </div>
    )
}

export default FormContainer;