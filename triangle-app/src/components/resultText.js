import React from 'react'
import './resultText.css';

function ResultText(props) {
    let txt = "nothing yet...";
    if (props.value) {
        txt = JSON.stringify(props.value, null, 2);        
    }
    return (
        <div>
            <h3>Triangle API Result</h3>            
            <textarea className="code" value={txt}/>
        </div>
    );
}

export default ResultText;