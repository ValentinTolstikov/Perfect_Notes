const login = document.getElementById('login');
const passw = document.getElementById('passw');
const passw_repeat = document.getElementById('passw_repeat');
const btn_reg = document.getElementById('btn_reg');

login.addEventListener('click', function login() {
    window.location.href = 'login';
});

btn_reg.addEventListener('click', function Validate() {
    if (passw.value != passw_repeat.value)
    {
        let msg = 'Пароль и повтор пароля должны совпадать';
        alert(msg);
    }
})