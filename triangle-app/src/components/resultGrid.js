import React, { Component } from 'react';
import './resultGrid.css';

class ResultGrid extends Component {
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
    }


    createGrid = ()=> {
        let shapes = [];
        const numrows = 6;
        const numcols = 6;
        const sideLength = 10 * this.viewMultiplier;
        const tri = this.props.value;
        //build the grid of triangles
        for (let rowidx=0; rowidx < numrows; rowidx++)
        {
            let rowChar = this.rowLetterMap[rowidx];
            let col = 0;
            for (let gridIdx=0; gridIdx < numcols; gridIdx++)
            {
                //define points- keep in mind, the sideLength
                //is multiplied by a 'zoom' factor
                let originTop = rowidx * sideLength;
                let originLeft = gridIdx * sideLength;
                let pTopLeft = `${originLeft} ${originTop}`;
                let pTopRight = `${originLeft + sideLength} ${originTop}`;
                let pBottomLeft = `${originLeft} ${originTop + sideLength}`;
                let pBottomRight = `${originLeft + sideLength} ${originTop + sideLength}`;
                //make 2 triangles
                let tri1 = `${pBottomLeft}, ${pBottomRight}, ${pTopLeft}`;
                shapes.push(<polygon className="emptyTriLight" points={tri1}></polygon>);
                let tri2 = `${pTopRight}, ${pTopLeft}, ${pBottomRight}`;
                shapes.push(<polygon className="emptyTriDark" points={tri2}></polygon>);

                //yes, i should calculate the center of the triangles, but i need to eat
                let lowerTextTop = originTop + sideLength - sideLength/4;
                let lowerTextLeft = originLeft + sideLength/4;
                shapes.push(<text x={lowerTextLeft} y={lowerTextTop}>{rowChar}{++col}</text>);
                
                let upperTextTop = originTop + sideLength/3;
                let upperTextLeft = originLeft + sideLength - sideLength/3;
                shapes.push(<text x={upperTextLeft} y={upperTextTop}>{rowChar}{++col}</text>)
                
            }
        }
        //highlight the searched-for triangle
        if (tri) {
            let pointA = this.getPointsForDisplay(tri.vertices[0], this.viewMultiplier);
            let pointB = this.getPointsForDisplay(tri.vertices[1], this.viewMultiplier);
            let pointC = this.getPointsForDisplay(tri.vertices[2], this.viewMultiplier);
            let highlightTri = `${pointA}, ${pointB}, ${pointC}`;
            shapes.push(<polygon className="highlightedTri" points={highlightTri}></polygon>); 
        }
        return shapes;

    }

    getPointsForDisplay(vertex, zoomFactor=1)
    {
        return `${vertex.left * zoomFactor} ${vertex.top * zoomFactor}`;
    }

    render() {
        
        return (
            <div className="canvasBox">
                <svg ref="svg" height="610" width="610">
                    {this.createGrid()}
                    
                </svg>
                
            </div>
        );
    }
}
export default ResultGrid;