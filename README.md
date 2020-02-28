# TriangleMan
This is a ASP.Net Core 3.1 project, with the Triangle API implemented using MVC. The only non-standard dependency is the NLog package.

The API has 2 methods:
- GetByCoordinates(x1y1, x2y2, x3y3)
- GetByRowCol(row, col)

Both methods return a Triangle model, which contains both vertex and row/col data. This version of the API assumes a constant number of rows (6) and columns (12), and a constant side length of 10.

# triangle-app
A React 16.12.0 app which calls the API. The Management apologizes for the crude implementation, The Author has never used React before, and he just wanted to take it for a spin.
Rest assured that The Author has been sacked.


Note: The solution file was created using VS 2019 Community, but VS Code (Linux) was used for most of the development. The projects will run in either IDE, Windows or Linux.
