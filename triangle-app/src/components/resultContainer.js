import React from 'react';
import ResultText from './resultText';
import ResultGrid from './resultGrid';

function ResultContainer(props) {
    return (
        <div className="resultContainer">
            <ResultText value={props.value}/>
            
            <ResultGrid value={props.value}/>
        </div>
    );
}

export default ResultContainer;