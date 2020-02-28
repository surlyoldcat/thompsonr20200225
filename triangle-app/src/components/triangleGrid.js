import React, { Component } from 'react';
import './triangleGrid.css';

class TriangleGrid extends Component {
    constructor(props) {
        super(props);
        this.viewMultiplier = 10;
        this.rowLetterMap = {
            0:"a",
            1:"b",
            2:"c",
            3:"d",
            4:"e",
            5:"f"
        };
        this.numrows = 6;
        this.numcols = 6;
        this.actualSideLength = 10;
        this.sideLength = this.actualSideLength * this.viewMultiplier;
        
        //this.createGrid = this.createGrid.bind(this);
        //this.createHighlightTriangle = this.createHighlightTriangle.bind(this);
    }


    createGrid = () => {
        let shapes = [];
        //build the grid of triangles
        for (let rowidx=0; rowidx < this.numrows; rowidx++)
        {
            let rowChar = this.rowLetterMap[rowidx];
            let col = 0;
            for (let gridIdx=0; gridIdx < this.numcols; gridIdx++)
            {
                //define points- keep in mind, the sideLength
                //is multiplied by a 'zoom' factor
                let originTop = rowidx * this.sideLength;
                let originLeft = gridIdx * this.sideLength;
                let pTopLeft = `${originLeft} ${originTop}`;
                let pTopRight = `${originLeft + this.sideLength} ${originTop}`;
                let pBottomLeft = `${originLeft} ${originTop + this.sideLength}`;
                let pBottomRight = `${originLeft + this.sideLength} ${originTop + this.sideLength}`;
                //make 2 triangles
                let tri1 = `${pBottomLeft}, ${pBottomRight}, ${pTopLeft}`;
                shapes.push(<polygon className="emptyTriLight" points={tri1}></polygon>);
                let tri2 = `${pTopRight}, ${pTopLeft}, ${pBottomRight}`;
                shapes.push(<polygon className="emptyTriDark" points={tri2}></polygon>);

                //yes, i should calculate the center of the triangles, but i need to eat
                let lowerTextTop = originTop + this.sideLength - this.sideLength/4;
                let lowerTextLeft = originLeft + this.sideLength/4;
                shapes.push(<text x={lowerTextLeft} y={lowerTextTop}>{rowChar}{++col}</text>);
                
                let upperTextTop = originTop + this.sideLength/3;
                let upperTextLeft = originLeft + this.sideLength - this.sideLength/3;
                shapes.push(<text x={upperTextLeft} y={upperTextTop}>{rowChar}{++col}</text>)
                
            }
        }
        const triElmt = this.createHighlightTriangle(this.props.value);
        if (triElmt) {
            shapes.push(triElmt);
        }
        return shapes;

    }

    createHighlightTriangle = (triangle) => {
        if (!triangle 
            || !triangle.vertices 
            || triangle.vertices.length===0)
            return null;
        
        const pointA = this.getPointsForDisplay(triangle.vertices[0], this.viewMultiplier);
        const pointB = this.getPointsForDisplay(triangle.vertices[1], this.viewMultiplier);
        const pointC = this.getPointsForDisplay(triangle.vertices[2], this.viewMultiplier);
        const highlightTri = `${pointA}, ${pointB}, ${pointC}`;
        return (
            <polygon className="highlightedTri" points={highlightTri}></polygon>
        );
        
    }

    getPointsForDisplay(vertex, zoomFactor=1)
    {
        return `${vertex.left * zoomFactor} ${vertex.top * zoomFactor}`;
    }

    createColHeaders = () => {
        let headers = [];
        for (let i = 0; i <= this.numcols; i++)
        {
            let left = i * this.sideLength;
            let display = i * this.actualSideLength;
            headers.push(<text className="colHeader" x={left} y="10">{display}</text>)
        }
        return headers;
    }

    render() {
        
        return (
            <div className="canvasBox">
               <svg height="10" width="615">
                {this.createColHeaders()}
               </svg>
               <br/>
                <svg height="610" width="610">
                    {this.createGrid()}1
                   
                </svg>
                
            </div>
        );
    }
}
export default TriangleGrid;