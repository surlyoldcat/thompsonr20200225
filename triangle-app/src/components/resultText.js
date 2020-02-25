import React from 'react'
import './resultText.css';

function ResultText(props) {
    let txt = "nothing yet...";
    if (props.value) {
        console.log(props.value);
        txt = JSON.stringify(props.value);
    }
    return (
        <div className="resultText">
        <h3>Triangle API Result</h3>
        <p className="triangleJson">{txt}</p>
        </div>
    );
}

export default ResultText;