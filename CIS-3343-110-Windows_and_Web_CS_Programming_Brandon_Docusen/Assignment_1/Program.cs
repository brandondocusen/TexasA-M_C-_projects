const fs = require('fs');
const path = require('path');
const { processFile } = require('./blackLister');  // Import the function from blackLister.js

async function processAllFiles() {
    const directoryPath = './allChannelsAndVideosTest';
    
    // Read all files from the directory
    const files = fs.readdirSync(directoryPath);
    
    for (let i = 0; i < files.length; i++) {
        const file = files[i];

        // Check if it's a CSV file
        if (path.extname(file) === '.csv') {
            const filePath = path.join(directoryPath, file);
            
            // Call the function from blackLister.js for each CSV file
            await processFile(filePath);
        }
    }

    console.log('All files processed!');
}

processAllFiles();