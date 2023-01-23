const AbstractPage = require('./AbstractPage')

class Stage2POCPage extends AbstractPage {

  get buttonStartTest() {
    return $('//button[contains(text(),"Start The Test")]')
  }

  get tableInteger() {
    return $('//*[@testid = "the-table"]/table[1]')
  }

  get h1TitleText() {
    return $('//h1')
  }

  async visit() {
    await browser.maximizeWindow()
    await browser.url('/')
  }

  async clickStartTest() {
    await this.buttonStartTest.click()
  }

  async validateIndex() {
    let rowData = [];
    super.waitAndDisplayed(this.h1TitleText);

    await this.tableInteger.$$('tr').forEach(element => {
      rowData.push(element);
    })

    for (let rowCtr = 1; rowCtr < rowData.length; rowCtr++) {
      let columnData = [];
      columnData = await $(rowData[rowCtr]).$$('td').map(element => element.getText());

      //find center
      for (let iCtr = 1; iCtr < columnData.length; iCtr++) {
        var leftSubsetSum = 0, rightSubsetSum = 0;

        columnData.slice(0, iCtr - 1).map(x => leftSubsetSum += parseInt(x));

        columnData.slice(iCtr, columnData.length).map(y => rightSubsetSum += parseInt(y))

        if (leftSubsetSum === rightSubsetSum) {
          console.log(`Row ${rowCtr}: Index ${iCtr} (with the value of ${columnData[iCtr - 1]})
             would be the center to return`);
             break;
        }
      }
    }
  }
}

module.exports = new Stage2POCPage()
