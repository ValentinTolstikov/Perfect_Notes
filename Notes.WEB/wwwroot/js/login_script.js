const remember_pas = document.getElementById('remember_pas');
const register = document.getElementById('register');
  
register.addEventListener('click', function reg() {
    window.location.href = 'register';
});

remember_pas.addEventListener('click', function reg() {
    window.location.href = 'rememberpas';
});
