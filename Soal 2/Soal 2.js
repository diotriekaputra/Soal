// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const f = (n) => {
    const arrs = [];
    for (let i = 0; i < n.length; i++) {
        let res = 1;
        for (let j = 0; j < n.length; j++) {
            if (i !== j) res *= n[j];
        }
        arrs.push(res)
    }
    console.log(arrs)
}

f([2, 8, 4, 5])