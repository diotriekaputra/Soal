// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const f = (n) => {
    for (let row = 0; row < n; row++) {
        let str = "";
        for (let col = 0; col < 10; col++) {
            if (col - 2 === row || col - 3 === row)
                str += "*";
            else
                str += col;
        }
        console.log(str);
    }
}

f(6)