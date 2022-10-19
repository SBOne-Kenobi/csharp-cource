using SparseMatrix;

namespace UnitTests;

public class SparseMatrixTest
{
    [Fact]
    public void TestTwoDims()
    {
        var matrix = new SparseMatrix<int>
        {
            [1, 2] = 124,
            [3, 15] = 24
        };

        {
            var expectedRecords = new List<SparseRecord<int>>
            {
                new(1, 2, 0, 124),
                new(3, 15, 0, 24)
            };

            Assert.Equal(expectedRecords, matrix);
        }

        matrix[2, 5] = -1;
        
        {
            var expectedRecords = new List<SparseRecord<int>>
            {
                new(1, 2, 0, 124),
                new(2, 5, 0, -1),
                new(3, 15, 0, 24)
            };

            Assert.Equal(expectedRecords, matrix);
        }

        matrix[1, 2] = 0;
        
        {
            var expectedRecords = new List<SparseRecord<int>>
            {
                new(2, 5, 0, -1),
                new(3, 15, 0, 24)
            };

            Assert.Equal(expectedRecords, matrix);
        }
        
        Assert.Throws<IndexOutOfRangeException>(() => matrix[1, 2, 5] = 24);
    }
}