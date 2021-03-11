
const X_UNICODE = '&#x2573';

const clearAttacher = () => {
    let attacher = document.getElementById('attacher');
    attacher.value = '';

    if (!/safari/i.test(navigator.userAgent)) {
        attacher.type = '';
        attacher.type = 'file';
    }
}

const deleteAndCleanFiles = (li, specificInputToClear = false) => {
    li.remove();
    clearAttacher();

    if (specificInputToClear)
        document.getElementById(specificInputToClear).value = '';
}

const fillList = (file, listType) => {
    let resultingList = document.getElementById('list_files');
    let item = listType(file);

    resultingList.appendChild(item);
}

const productUniqueImage = file => {
    var template = document.getElementById('product_unique_template');

    replaceUniqueFileValues(file);

    let newTemplate = template.cloneNode(true);

    let html = newTemplate.innerHTML.trim();
    newTemplate.innerHTML = replaceValues(html, file);

    let li = newTemplate.content.cloneNode(true);

    return li;
}

const replaceValues = (html, file) => {
    return html
        .replaceAll('file.name', file.name)
        .replaceAll('file.base64', file.base64)
        .replaceAll('X_UNICODE', X_UNICODE);
}

const addMultipleFilesToList = (filesArray, listType) => {
    filesArray.forEach(file => {
        fillList(file, listType);
    });
}

const replaceUniqueFileValues = (file) => {
    var inputResult = document.getElementById('fileResult');
    var inputPathImage = document.getElementById('filePath');

    document.getElementById('list_files').innerHTML = '';

    inputResult.value = '';
    inputResult.value = file.base64;
    inputPathImage.value = '';
    inputPathImage.value = file.name;
}