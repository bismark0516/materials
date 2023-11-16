
document.addEventListener("DOMContentLoaded", () => {

    const btn = document.querySelector('#btn1')

    btn.addEventListener('click', () => {
        document.body.classList.toggle('color_2')
    })
    btn.addEventListener('dblclick', () => {
        document.body.classList.remove('color_2')
        document.body.classList.toggle('color_3')

    })
})
