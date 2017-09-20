var pagination = {
    previous: null,
    previousDisabled: null,
    next: null,
    nextDisabled: null,
    countChunck: 0,
    currentChunk: 0,
    currentIndex: 0,
    totalCount: 0,
    countIndexPerChunk: 0,
    countObservationPerPage: 0,
    countPages: 0,
    pagerId: '',
    navigatePointer: null,
    //navigateName: '',
    setup: function (pagerId, navigatePointer, countIndexPerChunk, countObservationPerPage) {
        this.pagerId = pagerId;
        this.navigatePointer = navigatePointer;
        //this.navigateName = navigateName;
        this.countIndexPerChunk = countIndexPerChunk;
        this.countObservationPerPage = countObservationPerPage;
        this.previous = '<li><a href=# aria-label="Previous" onclick="return pagination.firstChunk();"><span aria-hidden="true">First</span></a></li>' +
            '<li><a href=# aria-label="Previous" onclick="return pagination.previousChunk();"><span aria-hidden="true">&laquo;</span></a></li>';
        this.previousDisabled = '<li class="disabled"><a href=# aria-label="Previous"><span aria-hidden="true">First</span></a></li>' +
            '<li class="disabled"><a href=# aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>';
        this.next = '<li><a href="#" aria-label=Next onclick="return pagination.nextChunk();"><span aria-hidden=true>&raquo;</span></a></li>' +
            '<li><a href=# aria-label="Previous" onclick="return pagination.lastChunk();"><span aria-hidden="true">Last</span></a></li>';
        this.nextDisabled = '<li class="disabled"><a href="#" aria-label=Next><span aria-hidden=true>&raquo;</span></a></li>' +
            '<li class="disabled"><a href=# aria-label="Previous"><span aria-hidden="true">Last</span></a></li>';
    },
    init: function (totalCount) { // totalCount has to be > 0       
        var indexPerChunk;
        $(this.pagerId).empty();
        this.countPages = parseInt(totalCount / this.countObservationPerPage) + ((totalCount % this.countObservationPerPage) == 0 ? 0 : 1);
        if (this.countPages == 1)
            return;
        if (this.countPages > this.countIndexPerChunk) {
            this.countChunk = parseInt(this.countPages / this.countIndexPerChunk) + ((this.countPages % this.countIndexPerChunk) == 0 ? 0 : 1);
            indexPerChunk = this.countIndexPerChunk;
        }
        else {
            indexPerChunk = this.countPages;
            this.countChunk = 0;
        }
        this.currentChunk = 0;
        this.currentIndex = this.currentChunk * indexPerChunk;
        var strCurrentIndex = (this.currentIndex + 1).toString();
        
        var alpha = this.setPages(this.currentIndex, indexPerChunk);
        if (indexPerChunk <= this.countIndexPerChunk && this.countChunk == 0)
            $(this.pagerId).append(alpha);
        else
            $(this.pagerId).append(this.previousDisabled + alpha + this.next);
    },
    navigate: function (elem) {
        $(elem).addClass('active pageSelection').siblings().removeClass('active pageSelection');
        this.currentIndex = $(elem)[0].id;
        this.navigatePointer(this.currentIndex);
        //doNavigate($(elem)[0].id);
    },
    setPages: function (currentIndex, lastIndexInChunk) {
        var alpha = '<li id="' + currentIndex.toString() + '" class="active pageSelection"><a href="#" onclick="return pagination.navigate(this.parentElement)">' + (currentIndex + 1).toString() + '</a></li>';
        var i;
        for (i = 1; i < lastIndexInChunk; i++) {
            var index = this.currentIndex + i;            
            alpha += '<li id="' + (index).toString() + '"><a href="#" onclick="return pagination.navigate(this.parentElement)">' + (index + 1).toString() + '</a></li>';
        }
        return alpha;
    },
    resetChunk: function () {
        $(this.pagerId).empty();
        this.currentIndex = this.currentChunk * this.countIndexPerChunk;
        var lastIndexInChunk = (this.countPages - this.currentIndex);
        if (lastIndexInChunk >= this.countIndexPerChunk)
            lastIndexInChunk = this.countIndexPerChunk;
        
        return this.setPages(this.currentIndex, lastIndexInChunk);
    },
    previousChunk: function () {
        this.currentChunk--;
        var alpha = this.resetChunk();
        $(this.pagerId).append((this.currentChunk > 0 ? this.previous : this.previousDisabled) + alpha + this.next);
        this.navigate($('#' + this.currentIndex.toString()));
    },
    nextChunk: function () {
        this.currentChunk++;
        var alpha = this.resetChunk();
        $(this.pagerId).append(this.previous + alpha + (this.currentChunk < this.countChunk - 1 ? this.next : this.nextDisabled));
        this.navigate($('#' + this.currentIndex.toString()));
    },
    firstChunk: function () {
        this.currentChunk = 0;

        $(this.pagerId).empty();

        this.currentIndex = 0;

        var lastIndexInChunk = (this.countPages - this.currentIndex);

        if (lastIndexInChunk >= this.countIndexPerChunk)
            lastIndexInChunk = this.countIndexPerChunk;
        
        var alpha = this.setPages(this.currentIndex, lastIndexInChunk);
        $(this.pagerId).append(this.previousDisabled + alpha + this.next);
        this.navigate($('#' + this.currentIndex.toString()));
    },
    lastChunk: function () {
        this.currentChunk = this.countChunk - 1;
        $(this.pagerId).empty();

        this.currentIndex = this.currentChunk * this.countIndexPerChunk;

        var lastIndexInChunk = (this.countPages - this.currentIndex);

        if (lastIndexInChunk >= this.countIndexPerChunk)
            lastIndexInChunk = this.countIndexPerChunk;
        
        var alpha = this.setPages(this.currentIndex, lastIndexInChunk);
        $(this.pagerId).append(this.previous + alpha + this.nextDisabled);        
        this.navigate($('#' + this.currentIndex.toString()));
    }
};