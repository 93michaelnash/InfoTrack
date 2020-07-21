const urlSelectorHitForm = document.getElementById('URL')
const resultsBox = document.getElementById('resultsBox');
const indexesBox = document.getElementById('indexesBox');
const resultsBoxTitle = document.getElementById('resultsBoxTitle');
const resultsAmountLabel = document.getElementById('resultsAmountLabel');
const resultsIndexesLabel = document.getElementById('searchResultsIndexes');
const googleRadiobox = document.getElementById('SelectedSearchOptionGoogle');
const bingRadiobox = document.getElementById('SelectedSearchOptionBing');

async function scrapeSite() { 
    const searchOptionValue = googleRadiobox.checked ? googleRadiobox.value : bingRadiobox.value;

    var validUrl = validateUrl();
    if (validUrl && validUrl.valid == false)
        return;

    const keywords = document.getElementById('Keywords').value.trim();
    var urlValue = urlSelectorHitForm.value.trim();
    const resultCount = document.getElementById('ResultCount').value.trim();

    const model = {
        URL: urlValue,
        Keywords: keywords,
        SelectedSearchOption: { Name: searchOptionValue },
        SelectedResultCount: { Value: resultCount }
    };

    await fetch("/Search", {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(model)
    }).then(function (response) {
        return response.json();
    })
        .then(result => {
            handleResult(result, `${searchOptionValue} Hits`);
        })
        .catch(function (error) {
            handleError(error, "Error");
        });
}

function handleResult(res, title) {
    indexesBox.hidden = true;
    resultsBoxTitle.textContent = title;
    resultsAmountLabel.textContent = `Occurences: ${res.count}`;
    if (res.count > 0) {
        resultsIndexesLabel.textContent = `In locations: ${res.indexes}`;
        indexesBox.hidden = false;
    }
                                
    resultsBox.hidden = false;
    window.scrollTo(0, document.body.scrollHeight);
}

function handleError(error, title) {
    resultsBoxTitle.textContent = title;
    resultsAmountLabel.textContent = error;
    resultsBox.hidden = false;
    window.scrollTo(0, document.body.scrollHeight);
}

function handleSubmit(e) {
    e.preventDefault();
    e.stopPropagation();
    return false;
}

function validateUrl() {
    var field = document.querySelector('#URL');
    var bouncer = new Bouncer();
    var isValid = bouncer.validate(field);
    return isValid;
}

urlSelectorHitForm.addEventListener('change', function () {
    validateUrl();
},
    false);