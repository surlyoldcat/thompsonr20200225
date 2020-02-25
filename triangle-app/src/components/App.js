import React, { Component } from 'react';
import './App.css';
import FormContainer from './formContainer';
import ResultContainer from './resultContainer';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      triangleParams:null,
      apiResult:null
    }
    this.handleTriangleRequested = this.handleTriangleRequested.bind(this);
  }

  render() {
    return (
      <div className="App">
        <header className="App-header">
          TriangleMan
        </header>
        <p className="disclaimer">Disclaimer: Rick doesn't know React. This is just a test harness.</p>
        <FormContainer triangleRequested={this.handleTriangleRequested}/>
        <ResultContainer value={this.state.apiResult}/>
      </div>
    );  
  }
  
  handleTriangleRequested(row,col) {
    console.log(`Requesting (${row}, ${col})`);
    const baseUrl = "http://localhost:5000/triangle/byrowcol";
    const query = `?row=${row}&col=${col}`;
    const url = baseUrl + query;
    fetch(url, {mode: 'cors', method:'GET'})
      .then(resp => resp.json())
      .then(data => this.setState({apiResult:data}))
      .catch(console.log);
  } 
}

export default App;
