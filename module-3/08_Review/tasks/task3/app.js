
document.addEventListener("DOMContentLoaded", () => {

    const btn = document.querySelector('.btn')
    btn.addEventListener('click', () => {
        const date = new Date();
        const currentDate = date.toString()

        const time = document.getElementById('time')
        time.innerText = currentDate;
    })
})


