const openEl = document.getElementById('open');
const closeEl = document.getElementById('close');
const container = document.querySelector('.container');

openEl.addEventListener('click', () => container.classList.add('show-nav'));
closeEl.addEventListener('click', () => container.classList.remove('show-nav'));