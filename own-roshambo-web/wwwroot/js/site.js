// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).on('click', '.login-accounts-trigger', function () {
    $(this).removeClass('is-active');
    $('.login-accounts-panel').addClass('is-active');
});

$(document).on('click', '.close-button', function () {
    $(this).closest('.login-accounts-panel').removeClass('is-active');
    $('.login-accounts-trigger').addClass('is-active');
});

$(document).on('click', '.login-block', function (e) {
    e.stopPropagation();
    let email = $(this).find('.fake-email').text();
    let password = $(this).find('.fake-password').text();
    $('form input[Name="Email"]').val(email);
    $('form input[Name="Password"]').val(password);
});

var choosRivalHtml = `<form class="py-4"><div class="row">
<div class="col-md-6">
    <label class="w-100" for="rivale-type-realtime">
        <div class="game-alert-card card card-1">
            <h3 class="game-alert-card-title">Realtime</h3>
            <p class="game-alert-card-text">Play in real time with other players. Show your superiority over other players.</p>
            <span class="game-alert-card--realtime-icon">&#129338;</span>
            <input type="radio" value="10" id="rivale-type-realtime" name="rivale-type" checked/>
        </div>
    </label>
</div>
<div class="col-md-6">
    <label class="w-100" for="rivale-type-ai">
        <div class="game-alert-card game-alert-card--disabled game-alert-card card card-1">
            <h3 class="game-alert-card-title">AI</h3>
            <p class="game-alert-card-text">Play against artificial intelligence and try to prove you're smarter. Psst AI isn't much smart.</p>
            <span class="game-alert-card--ai-icon">&#129302;</span>
            <div class="d-flex align-items-center ">
                <input type="radio" value="20" name="rivale-type" disabled />
                <p class="game-alert-card-soon">Coming Soon!</p>
            </div>
        </div>
    </label>
</div>
</div></form>`;

var formHtml = `<div class="d-flex justify-content-center"><form class="w-50">
<div class="mb-3 py-4 d-flex flex-column align-items-start">
    <label for="name-input" class="form-label">Name</label>
    <input id="name-input" class="form-control" name="game-name" placeholder="Enter game name" />
    <div class="form-text error-text text-danger font-weight-bold"></div>
  </div>
</form><div>`;

function getType(type) {
    let currentType;
    switch (type) {
        case "10":
            currentType = "Realtime rivale";
            break;
        case "20":
            currentType = "AI rivale";
            break;
    }
    return currentType;
}

function overviewGameHtml(result) {
    let createGameResult = {};
    createGameResult.type = result.value[0];
    createGameResult.name = result.value[1];

    var overviewGameHtml = `<div class="d-flex justify-content-center"><div class="w-50">
        <div class="mb-4"><p class="overview-title m-0">Type:</p><p class="overview-text m-0">${getType(createGameResult.type)}</p></div>
        <div><p class="overview-title m-0">Name:</p><p class="overview-text m-0">${createGameResult.name}</p></div>
    </div></div>`;
    return overviewGameHtml;
}

$(document).on('click', '.create-game', function () {
    var isValid;
    Swal.mixin({
        width: 800,
        confirmButtonText: 'Next &rarr;',
        showCancelButton: true,
        progressSteps: ['1', '2'],
    }).queue([
        {
            title: 'Choose Rival',
            html: choosRivalHtml,
            preConfirm: function () {
                $(".confirm").attr('disabled', 'disabled');
                let rivaleType = $("input[Name=rivale-type]").val();
                if (!rivaleType) {
                    return null;
                }
                return value = rivaleType;
            }
        },
        {
            title: 'Settings',
            html: formHtml,
            preConfirm: function () {
                let gameName = $("input[Name=game-name]").val();
                if (!gameName) {
                    return null;
                }
                return value = gameName;
            }
        },
    ]).then((result) => {
        Swal.fire({
            title: 'Overview',
            html: overviewGameHtml(result),
            confirmButtonText: 'Create Game',
            showCancelButton: true,
            onOpen: function () {
                console.log(result)
                if (result.value[0] && result.value[1]) {
                    $(".swal2-confirm").removeAttr('disabled', 'disabled');

                } else {
                    $(".swal2-confirm").attr('disabled', 'disabled');
                }
            }
        })
    })
});
