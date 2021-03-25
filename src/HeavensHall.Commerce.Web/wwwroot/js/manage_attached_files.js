
var imagesArray = [];

const X_UNICODE = '&#x2573';

const storeImageValue = file => imagesArray.push({ Name: file.name, Base64: file.base64 });

const addImagesValuesToFormData = () => {
    if (imagesArray.length <= 0) return false;

    let addedImages = JSON.stringify(imagesArray);
    document.getElementById('images').value = `${addedImages}`;

    return true;
}

const deleteFromImagesArray = index => {
    imagesArray.splice(index, 1);
}

const clearAttacher = () => {
    let attacher = document.getElementById('attacher');
    attacher.value = '';

    if (!/safari/i.test(navigator.userAgent)) {
        attacher.type = '';
        attacher.type = 'file';
    }
}

const deleteAndCleanFiles = (elementToRemove, deleteImageFromFormData = false) => {
    if (deleteImageFromFormData) {
        let indexOfElementToRemove = getImageElementIndexFromParent(elementToRemove);
        deleteFromImagesArray(indexOfElementToRemove);
    }

    elementToRemove.remove();
    clearAttacher();
}

const getImageElementIndexFromParent = element => Array.from(element.parentNode.children).indexOf(element);

const fillList = (file, listType) => {
    let resultingList = document.getElementById('list_files');
    let item = listType(file);

    resultingList.appendChild(item);
    storeImageValue(file);
}

const replaceValues = (html, file) => {
    return html
        .replaceAll('file.name', file.name)
        .replaceAll('file.base64', file.base64)
        .replaceAll('imageId', Math.random().toString(36).substr(2, 5)) // 5 random characters.
        .replaceAll('X_UNICODE', X_UNICODE);
}

const multipleCardImages = file => {
    var template = document.getElementById('card-images-template');
    let newTemplate = template.cloneNode(true);

    let html = newTemplate.innerHTML.trim();
    newTemplate.innerHTML = replaceValues(html, file);

    let templateFilled = newTemplate.content.cloneNode(true);

    return templateFilled;
}

const selectAsMainImage = element => {
    let imageIndex = getImageElementIndexFromParent(element);

    //Replace old values if exists
    imagesArray = imagesArray.map(img => {
        delete img.Main;
        return img;
    });

    imagesArray[imageIndex].Main = true;
}
